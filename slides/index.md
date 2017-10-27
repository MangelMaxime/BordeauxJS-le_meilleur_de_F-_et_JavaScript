- title : Le meilleur de F# et JavaScript
- description : Introduction à Fable
- author : Maxime Mangel
- theme : night
- transition : default

***

## Le meilleur de F# et JavaScript

<br />
<br />

### Une introduction à Fable

<br />
<br />
Maxime Mangel - [@mangelmaxime](http://www.twitter.com/mangelmaxime)

***

### Maxime Mangel

* Contributeur à l'éco-sytème de Fable
* Mainteneur de:
    * Elmish
    * Fulma
    * Hink

***

* Fable
    * Présentation
    * Examples
* Elmish
    * Concept
    * Easy to debug
* Tooling
    * Hot loading
    * HMR
    * Intellisense
* Eco-système
    * Fulma
    * React

***

### Fable 

- F#
    - Synthaxe
        - Concise
        - Moin de pollution
    - *Si ça compile, ça marche*
- Interop simple
- Utiliser l'existants
    - Webpack, Rollup
    - Babel 
    - VSCode/Ionide
    - Visual Studio, Rider, etc.

[Fable docs](http://fable.io/docs/)

---

### Fable 

> Fable is an F# to JavaScript compiler powered by Babel, designed to produce readable and standard code.

[Démo repl](https://goo.gl/ZJSgzL)

---

### Fable

#### Examples

* Fable
    * [Démo](http://fable.io/samples-browser/)
* Pixi + AnimeJS
    * [Démo](http://fable.io/samples-pixi/basic/)
    * [Code](https://github.com/fable-compiler/samples-pixi/blob/master/src/basic/App.fs)

*** 

### Elmish

#### Model - View - Update

 <img src="images/Elm.png" style="background: white;" width=700 />

 <small>http://danielbachler.de/2016/02/11/berlinjs-talk-about-elm.html</small>


--- 

### Model - View - Update

    // MODEL

    type Model = int

    type Msg =
    | Increment
    | Decrement

    let init() : Model = 0

---

### Model - View - Update

    // VIEW

    let view model dispatch =
        div []
            [ button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ]
              div [] [ str (model.ToString()) ]
              button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ] ]

---

### Model - View - Update

    // UPDATE

    let update (msg:Msg) (model:Model) =
        match msg with
        | Increment -> model + 1
        | Decrement -> model - 1

---

### Model - View - Update

    // wiring things up

    Program.mkSimple init update view
    |> Program.withConsoleTrace
    |> Program.withReact "elmish-app"
    |> Program.run

***

### Sub-Components

    // MODEL

    type Model = {
        Counters : Counter.Model list
    }

    type Msg = 
    | Insert
    | Remove
    | Modify of int * Counter.Msg

    let init() : Model =
        { Counters = [] }

---

### Sub-Components

    // VIEW

    let view model dispatch =
        let counterDispatch i msg = dispatch (Modify (i, msg))

        let counters =
            model.Counters
            |> List.mapi (fun i c -> Counter.view c (counterDispatch i)) 
        
        div [] [ 
            yield button [ OnClick (fun _ -> dispatch Remove) ] [  str "Remove" ]
            yield button [ OnClick (fun _ -> dispatch Insert) ] [ str "Add" ] 
            yield! counters ]

---

### Sub-Components

    // UPDATE

    let update (msg:Msg) (model:Model) =
        match msg with
        | Insert ->
            { Counters = Counter.init() :: model.Counters }
        | Remove ->
            { Counters = 
                match model.Counters with
                | [] -> []
                | x :: rest -> rest }
        | Modify (id, counterMsg) ->
            { Counters =
                model.Counters
                |> List.mapi (fun i counterModel -> 
                    if i = id then
                        Counter.update counterMsg counterModel
                    else
                        counterModel) }

***

### React

* Facebook library for UI 
* <code>state => view</code>
* Virtual DOM

---

### Virtual DOM - Initial

<br />
<br />


 <img src="images/onchange_vdom_initial.svg" style="background: white;" />

<br />
<br />

 <small>http://teropa.info/blog/2015/03/02/change-and-its-detection-in-javascript-frameworks.html</small>

---

### Virtual DOM - Change

<br />
<br />


 <img src="images/onchange_vdom_change.svg" style="background: white;" />

<br />
<br />

 <small>http://teropa.info/blog/2015/03/02/change-and-its-detection-in-javascript-frameworks.html</small>

---

### Virtual DOM - Reuse

<br />
<br />


 <img src="images/onchange_immutable.svg" style="background: white;" />

<br />
<br />

 <small>http://teropa.info/blog/2015/03/02/change-and-its-detection-in-javascript-frameworks.html</small>


*** 

### C'est l'heure de déveloper :)

*** 

### Liens utile

* https://github.com/kunjee17/awesome-fable
* https://twitter.com/FableCompiler/
* http://fable.io

*** 

### Merci !

* https://twitter.com/mangelmaxime
* https://github.com/MangelMaxime
* https://gitter.im/fable-compiler/
* F# Slack
