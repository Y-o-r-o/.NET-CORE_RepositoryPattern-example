# Terraform with AzureRm.

Description.

## Installation

* Install Azure CLI https://docs.microsoft.com/en-us/cli/azure/install-azure-cli
* Install terraform from https://terraform.io

## Usage

### Authenticate terraform to azure.
1) Login with Azure CLI with the PowerShell `az login` command so that terraform could use your Azure account.
2) Select a subscription account. PowerShell: `az account set --subscription <Azure-SubscriptionId>`

### Setup state file in the cloud.
Terraform must store the state of your managed infrastructure and configuration. Terraform uses this state file to map real-world resources to your configuration, keep track of metadata, and improve performance for large infrastructures.

This state is stored by default in a local file named "terraform.tfstate", but it can also be stored remotely, which works better in a team environment.

 1) In azure portal or CLI create resource_group -> storage_account -> container_name. Then fill in providers.tf azurerm backend.
```HCL
terraform {
  required_version = ">= 1.2.5"
  backend "azurerm" {
    resource_group_name  = "resource group name"
    storage_account_name = "storage account name"
    container_name       = "container name"
    key                  = "terraform.tfstate"
  }
}
```
### Run terraform.
1) Run command `terraform init` to initialize terraform. With this command terraform downloads required providers, builds modules dependencies, checks if code is correct, etc..
2) Run command `terraform plan -var-file="environment/<yours environment>.tfvars"` (for tfvars sample watch environment/development.tfvars.example file). This command creates an execution plan, which lets you preview the changes that Terraform plans to make to your infrastructure.
3) Run command `terraform apply -var-file="environment/<yours environment>.tfvars"` this command executes the actions proposed in a Terraform plan.

## Contributing
Pull requests are welcome. For significant changes, please open an issue first to discuss what you would like to change.