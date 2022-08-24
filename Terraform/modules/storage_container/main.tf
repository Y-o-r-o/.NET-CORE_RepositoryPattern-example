# Create a Storage Container for the Core State File
resource "azurerm_storage_container" "tfstate" {
  depends_on = [azurerm_storage_account.tfstate]

  name                 = "tfstate"
  storage_account_name = azurerm_storage_account.tfstate.name
}

# Create a Storage Account for the Terraform State File
resource "azurerm_storage_account" "tfstate" {
  depends_on                = [var.storage_account_depends_on]
  name                      = "${lower(var.company)}tf${random_string.tf-name.result}"
  resource_group_name       = var.tfstate_rg_name
  location                  = var.tfstate_rg_location
  account_kind              = var.account_kind
  account_tier              = var.account_tier
  access_tier               = var.account_access_tier
  account_replication_type  = var.account_replication_type
  enable_https_traffic_only = var.is_traffic_only

  lifecycle {
    prevent_destroy = true
  }

  tags = {
    environment = var.environment
  }
}

# Generate a random storage name
resource "random_string" "tf-name" {
  length  = 8
  upper   = false
  numeric = true
  lower   = true
  special = false
}
