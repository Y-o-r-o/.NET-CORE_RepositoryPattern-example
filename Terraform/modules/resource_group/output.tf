output "tfstate_rg_name" {
  value = azurerm_resource_group.tfstate.name
}

output "tfstate_rg_location" {
  value = azurerm_resource_group.tfstate.location
}

output "dev_rg_name" {
  value = azurerm_resource_group.dev.name
}

output "dev_rg_location" {
  value = azurerm_resource_group.dev.location
}

output tfstate_rg {
  value = {}

  depends_on = [
    azurerm_resource_group.tfstate
  ]
}

output dev_rg {
  value = {}

  depends_on = [
    azurerm_resource_group.dev
  ]
}