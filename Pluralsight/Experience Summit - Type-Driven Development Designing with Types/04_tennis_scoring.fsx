(*
    Example 1
    Start at Love - Love
    Player 2 scores, Love - 15
    Player 1 scores, 15 - 15
    Player 2 scores, 15 - 30
    Player 2 scores, 15 - 40
    Player 2 scores, Game (Player 2 wins)
*)

type Player =
| Player1 
| Player2

type Score = 
| Love
| Fifteen
| Thirty
| Forty 
| Game

type GameState = {
    Player1Score: Score
    Player2Score: Score
}

let initialGameScore = { 
    Player1Score = Love 
    Player2Score = Love 
}

let initializeGame =
    (printfn "%s" <| "Start at Love - Love"); 
    initialGameScore

let nextScore currentScore: Score = 
    match currentScore with 
    | Love -> Fifteen
    | Fifteen -> Thirty
    | Thirty -> Forty
    | Forty -> Game
    | _ -> failwith "Invalid option"

let score player currentScore newPlayerScore =
    match player with
    | Player1 _ -> 
        let score = { Player1Score = newPlayerScore; Player2Score = currentScore.Player2Score }
        printfn $"{player} scores, {score.Player1Score} - {score.Player2Score}"
        score
    | Player2 _ ->  
        let score = { Player1Score = currentScore.Player1Score; Player2Score = newPlayerScore }
        printfn $"{player} scores, {score.Player1Score} - {score.Player2Score}"
        score

let win player newPlayerScore = 
    printfn $"{player} scores, {newPlayerScore} ({player} wins)"
    initialGameScore

let awardPoint (toPlayer: Player) (currentGameState: GameState) : GameState =
    match toPlayer with
    | Player1 _ -> 
        let newPlayer1Score = nextScore(currentGameState.Player1Score)
        match newPlayer1Score with
        | Game -> win toPlayer newPlayer1Score
        | _ -> score toPlayer currentGameState newPlayer1Score
    | Player2 _ ->  
        let newPlayer2Score = nextScore(currentGameState.Player2Score)
        match newPlayer2Score with
        | Game -> win toPlayer newPlayer2Score
        | _ -> score toPlayer currentGameState newPlayer2Score

initializeGame
|> awardPoint Player2
|> awardPoint Player1
|> awardPoint Player2
|> awardPoint Player2
|> awardPoint Player2