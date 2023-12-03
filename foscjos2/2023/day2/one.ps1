$inputFile = Get-Content .\input.txt
$total = 0
$gameLimits = @{ red = 12; green = 13; blue = 14; }

# need to log the game numbers
# then check if the number of cubes per color makes sense
# if it does, add game number to total
# if not, immediately cut to next iteration of loop

ForEach ($line in $inputFile) {
    $line = $line.Replace(':', '')
    $line = $line.Replace(',', '')
    $line = $line.Replace(';', '')
    $line = $line.Replace('Game ', '')
    $split = $line -split " "
    $currentGame = $split[0]
    $currentNumber = -1
    $currentColor = ''

    $validGame = $true

    ForEach ($item in $split) {
        If ($item -match "^\d+$") {
            $currentNumber = $item
        } Else {
            $currentColor = $item
        }

        If ($currentColor -ne '') {
            # Write-Host $currentColor
            # Write-Host $gameLimits[$currentColor]
            # Write-Host $currentNumber

            [int]$currentNumber = [convert]::ToInt32($currentNumber, 10)

            if ($currentNumber -gt $gameLimits[$currentColor]) {
                $validGame = $false
                break
            }

            $currentColor = ''
        }
    }

    # Write-Host "Game $currentGame : $validGame"

    if ($validGame -eq $true) {
        $total += $currentGame
    }
}

Write-Host "Total: $total"