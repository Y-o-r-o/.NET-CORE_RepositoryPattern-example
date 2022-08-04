# Define Terraform provider
terraform {
  required_version = ">= 1.2.5"
}

# Configure the Azure provider
provider "azurerm" {
  environment     = "public"
  subscription_id = var.azure-subscription-id
  client_id       = var.azure-client-id
  client_secret   = var.azure-client-secret
  tenant_id       = var.azure-tenant-id
  features {}
}
