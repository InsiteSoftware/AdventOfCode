$inputFile = Get-Content .\input.txt
$total = 0

# find the min number for each color per game
# multiply those numbers together
# then add to the total

ForEach ($line in $inputFile) {
    $line = $line.Replace(':', '')
    $line = $line.Replace(',', '')
    $line = $line.Replace('Game ', '')
    $split = $line -split ";"

    $currentNumber = 0
    $currentColor = ''
    $minRed = 0
    $minGreen = 0
    $minBlue = 0

    ForEach ($item in $split) {
        $split2 = $item -split " "

        ForEach ($item2 in $split2) {
            If ($item2 -match "^\d+$") {
                $currentNumber = $item2
            } Else {
                $currentColor = $item2
            }

            If ($currentColor -ne '') {
                [int]$currentNumber = [convert]::ToInt32($currentNumber, 10)

                # Write-Host $currentColor $currentNumber

                if ($currentColor -eq 'red') {
                    if ($currentNumber -gt $minRed) {
                        $minRed = $currentNumber
                    }
                } ElseIf ($currentColor -eq 'green') {
                    if ($currentNumber -gt $minGreen) {
                        $minGreen = $currentNumber
                    }
                } ElseIf ($currentColor -eq 'blue') {
                    if ($currentNumber -gt $minBlue) {
                        $minBlue = $currentNumber
                    }
                }

                $currentColor = ''
                $currentNumber = 0
            }
        }
    }

    $total += ($minRed * $minGreen * $minBlue)
}

Write-Host "Total: $total"