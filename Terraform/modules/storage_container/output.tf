output "terraform_state_storage_account" {
  value = azurerm_storage_account.tfstate.name
}

output "terraform_state_storage_container_core" {
  value = azurerm_storage_container.tfstate.name
}