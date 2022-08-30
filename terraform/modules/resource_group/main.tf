# Create a Resource Group for Web App
resource "azurerm_resource_group" "rep_pattern" {
  name     = "repository_pattern"
  location = var.rg_location

  lifecycle {
    prevent_destroy = true
  }
}
