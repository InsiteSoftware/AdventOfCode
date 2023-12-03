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
    $currentNumber = -1
    $currentColor = ''
    $minRed = -1
    $minGreen = -1
    $minBlue = -1

    $validGame = $true

    ForEach ($item in $split) {
        $split2 = $item -split " "

        ForEach ($item2 in $split2) {
            Write-Host $item2

            If ($item -match "^\d+$") {
                $currentNumber = $item
            } Else {
                $currentColor = $item
            }

            If ($currentColor -ne '') {
                [int]$currentNumber = [convert]::ToInt32($currentNumber, 10)

                if ($currentNumber -gt $gameLimits[$currentColor]) {
                    $validGame = $false
                    break
                }

                $currentColor = ''
            }
        }
    }

    if ($validGame -eq $true) {
        $total += $currentGame
    }
}

Write-Host "Total: $total"