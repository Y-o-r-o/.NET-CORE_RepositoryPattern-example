# Define Terraform provider
terraform {
  required_version = ">= 1.2.5"
  backend "azurerm" {
    resource_group_name  = "terraform_tfstate"
    storage_account_name = "tfstate0096"
    container_name       = "tfstate"
    key                  = "terraform.tfstate"
  }
}

# Configure the Azure provider
provider "azurerm" {
  environment = "public"
  features {}
}