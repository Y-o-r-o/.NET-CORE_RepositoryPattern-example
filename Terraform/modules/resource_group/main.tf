# Create a Resource Group for the Terraform State File
resource "azurerm_resource_group" "tfstate" {
  name     = "${lower(var.company)}-tfstate-rg"
  location = var.rg_location

  lifecycle {
    prevent_destroy = true
  }

  tags = {
    environment = var.environment
  }
}

# Create a Resource Group for Web App
resource "azurerm_resource_group" "dev" {
  name     = "development-rg"
  location = var.rg_location

  lifecycle {
    prevent_destroy = true
  }
}
