
resource "azurerm_windows_web_app" "rep_pattern" {
  name                = var.web_app_name
  resource_group_name = var.rep_pattern_rg_name
  location            = var.rep_pattern_rg_location
  service_plan_id     = azurerm_service_plan.rep_pattern.id

  site_config {
    always_on = false
  }

  app_settings = tomap({
    "ASPNETCORE_ENVIRONMENT" = var.environment
  })

}

resource "azurerm_service_plan" "rep_pattern" {
  name                = "development-sp"
  resource_group_name = var.rep_pattern_rg_name
  location            = var.rep_pattern_rg_location
  sku_name            = var.sku_tier
  os_type             = var.os_type
}
