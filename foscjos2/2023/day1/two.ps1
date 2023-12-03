$inputFile = Get-Content .\input.txt
$total = 0
$hash = @{ one = '1'; two = '2'; three = '3'; four = '4'; five = '5'; six = '6'; seven = '7'; eight = '8'; nine = '9' }
$numbers = @('one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine')
$numRegex = [string]::Join('|', $numbers)

ForEach ($line in $inputFile) {
    $split = $line -split ""

    $firstNum = -1
    $lastNum = -1
    $tryRegex = $false
    $testString = ''

    if ($line -match $numRegex) {
        $tryRegex = $true
    }

    ForEach ($char in $split) {
        If ($char -match "^\d+$") {
            $lastNum = $char
            If ($firstNum -eq -1) {
                $firstNum = $char
            }
            $testString = ''
        } ElseIf ($tryRegex -eq $true) {
            $testString += $char
            If ($testString -match $numRegex) {
                $lastNum = $testString
                If ($firstNum -eq -1) {
                    $firstNum = $testString
                }
                # there could be an overlap here (eightwo) and we want to be able to catch that second number
                $testString = $char
            }
        }
    }

    # if the number was in string form, convert it here before we add it to the total
    If (-Not ($firstNum -match "^\d+$")) {
        $firstNum = $firstNum -replace "(?s).*?($numRegex).*", '$1'
        $firstNum = $hash[$firstNum]
    }

    If (-Not ($lastNum -match "^\d+$")) {
        $lastNum = $lastNum -replace "(?s).*?($numRegex).*", '$1'
        $lastNum = $hash[$lastNum]
    }

    $toAdd = $firstNum + $lastNum

    $total += $toAdd
}

Write-Host "Total: $total"