
resource "azurerm_windows_web_app" "repPattern" {
  name                = var.web_app_name
  resource_group_name = var.repPattern_rg_name
  location            = var.repPattern_rg_location
  service_plan_id     = azurerm_service_plan.repPattern.id

  site_config {
    always_on = false
  }
}

resource "azurerm_service_plan" "repPattern" {
  name                = "development-sp"
  resource_group_name = var.repPattern_rg_name
  location            = var.repPattern_rg_location
  sku_name            = var.sku_tier
  os_type             = var.os_type
}
