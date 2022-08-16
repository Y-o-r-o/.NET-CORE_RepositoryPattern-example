# Define Terraform provider
terraform {
  required_version = ">= 1.2.5"
  backend "azurerm" {
    resource_group_name  = "development-rg"
    storage_account_name = "testinctfo9pooooz"
    container_name       = "core-tfstate"
    key                  = "terraform.tfstate"
  }
}

# Configure the Azure provider
provider "azurerm" {
  environment     = "public"
  features {}
}
