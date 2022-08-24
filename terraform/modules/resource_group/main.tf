# Create a Resource Group for Web App
resource "azurerm_resource_group" "dev" {
  name     = "development-rg"
  location = var.rg_location

  lifecycle {
    prevent_destroy = true
  }
}
