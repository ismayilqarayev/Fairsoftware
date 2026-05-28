<#
Copies hooks from .githooks/ into .git/hooks/ in the repository root.
Run this from the repository root:
  .\scripts\install_git_hooks.ps1
#>

param()

$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$repoRoot = Resolve-Path "$scriptDir\.." | Select-Object -ExpandProperty Path
$source = Join-Path $repoRoot '.githooks'
$dest = Join-Path $repoRoot '.git\hooks'

if (-not (Test-Path $source)) {
    Write-Error "Source hooks folder not found: $source"
    exit 1
}

if (-not (Test-Path $dest)) {
    Write-Error "No .git/hooks directory found. Are you in a git repository?"
    exit 1
}

Get-ChildItem -Path $source -File | ForEach-Object {
    $target = Join-Path $dest $_.Name
    Copy-Item -Path $_.FullName -Destination $target -Force
    Write-Host "Installed hook: $($_.Name) -> .git/hooks/"
}

Write-Host "Hooks installed. If needed, make sure hook files are executable (on Unix)."