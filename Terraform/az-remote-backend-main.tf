
# Generate a random storage name
resource "random_string" "tf-name" {
  length    = 8
  upper     = false
  numeric   = true
  lower     = true
  special   = false
}

# Create a Resource Group for the Terraform State File
resource "azurerm_resource_group" "tfstate" {
  name     = "${lower(var.company)}-tfstate-rg"
  location = var.location  
  
  lifecycle {
    prevent_destroy = true
  }  
  
  tags = {
    environment = var.environment
  }
}

# Create a Storage Account for the Terraform State File
resource "azurerm_storage_account" "tfstate" {
  depends_on                = [azurerm_resource_group.tfstate]  
  name                      = "${lower(var.company)}tf${random_string.tf-name.result}"
  resource_group_name       = azurerm_resource_group.tfstate.name
  location                  = azurerm_resource_group.tfstate.location
  account_kind              = "StorageV2"
  account_tier              = "Standard"
  access_tier               = "Hot"
  account_replication_type  = "ZRS"
  enable_https_traffic_only = true
   
  lifecycle {
    prevent_destroy = true
  }  
  
  tags = {
    environment = var.environment
  }
}

# Create a Storage Container for the Core State File
resource "azurerm_storage_container" "tfstate" {
  depends_on = [azurerm_storage_account.tfstate]  
  
  name                 = "core-tfstate"
  storage_account_name = azurerm_storage_account.tfstate.name
}



resource "azurerm_resource_group" "dev" {
  name     = "development-rg"
  location = var.location
}

resource "azurerm_service_plan" "dev" {
  name                = "development-sp"
  location            = azurerm_resource_group.dev.location
  resource_group_name = azurerm_resource_group.dev.name
  sku_name            = "F1"
  os_type             = "Windows"
}

resource "azurerm_windows_web_app" "dev" {
  name                = "development-web-app"
  resource_group_name = azurerm_resource_group.dev.name
  location            = azurerm_resource_group.dev.location
  service_plan_id     = azurerm_service_plan.dev.id
  
  site_config {
    always_on = false
  }
}

resource "azurerm_mssql_server" "dev" {
  name                         = "orionincdevdb"
  resource_group_name          = azurerm_resource_group.dev.name
  location                     = "west europe"
  version                      = "12.0"
  administrator_login          = "testadmin"
  administrator_login_password = "AdminOfThisTestDB@1@2"
}