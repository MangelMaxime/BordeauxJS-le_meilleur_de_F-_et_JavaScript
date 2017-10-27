open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

[<Pojo>]
type User =
  { Id : int
    Firstname : string
    Surname : string
    Age : int
    Email : string }
    
let maxime =
  { Id = 1
    Firstname = "Maxime"
    Surname = "Mangel"
    Age = 25
    Email = "mangel.maxime@protonmail.com" }

let printFirstname user = 
  Browser.console.log user.Firstname
  user

let printAge user =
  Browser.console.log user.Age
  user
  
maxime
|> printFirstname
|> printAge
