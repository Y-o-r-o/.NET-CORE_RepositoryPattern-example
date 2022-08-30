output "rep_pattern_rg_name" {
  value = azurerm_resource_group.rep_pattern.name
}

output "rep_pattern_rg_location" {
  value = azurerm_resource_group.rep_pattern.location
}

output rep_pattern_rg {
  value = {}

  depends_on = [
    azurerm_resource_group.rep_pattern
  ]
}