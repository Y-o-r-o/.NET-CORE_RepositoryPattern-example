# Define Terraform provider
terraform {
  required_version = ">= 1.2.5"
  backend "azurerm" {
    resource_group_name  = "development-rg"
    storage_account_name = "testinctfo9pooooz"
    container_name       = "core-tfstate"
    key                  = "terraform.tfstate"
    access_key           = "pFfKZf6Plav2bVYB04N4DPJgHm3tLHyPdVWP9tOBTKRLDOpjer3fIEsIfju1fWmAVJ4j/7cJWvEE+ASttT4JaA=="
  }
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
