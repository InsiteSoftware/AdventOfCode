Write-Host "Reading input file..."

$input = Get-Content .\input.txt
$total = 0

ForEach ($line in $input) {
    $split = $line -split ""

    $firstNum = -1
    $lastNum = -1

    ForEach ($char in $split) {
        If ($char -match "^\d+$") {
            $lastNum = $char
            If ($firstNum -eq -1) {
                $firstNum = $char
            }
        }
    }

    $toAdd = $firstNum + $lastNum

    $total += $toAdd
}

Write-Host "Total: $total"