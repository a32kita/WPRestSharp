Write-Host ("git add *; git commit --allow-empty -m `"" + [DateTime]::Now.ToString("yyyyMMddHHmmss") + " checkpoint`"; git push origin develop")
Read-Host