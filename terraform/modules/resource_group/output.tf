output "repPattern_rg_name" {
  value = azurerm_resource_group.repPattern.name
}

output "repPattern_rg_location" {
  value = azurerm_resource_group.repPattern.location
}

output repPattern_rg {
  value = {}

  depends_on = [
    azurerm_resource_group.repPattern
  ]
}