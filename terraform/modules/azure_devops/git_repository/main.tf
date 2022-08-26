resource "azuredevops_git_repository" "rep_pattern" {
  project_id = azuredevops_project.rep_pattern.id
  name       = "AzTerraform"
  initialization {
    init_type   = "Import"
    source_type = "Git"
    source_url  = "https://github.com/microsoft/terraform-provider-azuredevops.git"
  }
}