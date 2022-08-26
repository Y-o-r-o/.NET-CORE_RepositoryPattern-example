resource "azuredevops_project" "rep_pattern" {
  name               = "TesDevOps"
  visibility         = "private"
  version_control    = "Git"
  work_item_template = "Basic"
  description        = "Managed by Terraform"
}