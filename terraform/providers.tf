# Define Terraform provider
terraform {
  required_version = ">= 1.2.5"
  backend "azurerm" {
    resource_group_name  = "terraform_tfstate"
    storage_account_name = "tfstate0095"
    container_name       = "tfstate"
    key                  = "terraform.tfstate"
    # To add access_key - PowerShell: $env:ARM_ACCESS_KEY="000000000000-00000-00000-000000000"
  }
}

# Configure the Azure provider
provider "azurerm" {
  environment = "public"
  features {}
}