namespace WSTemplate

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Html
open WebSharper.UI.Next.Client

[<JavaScript>]
module Client =   
    
    type Hello = Templating.Template<"templates\hello.html">
    type Ul = Templating.Template<"templates\ul.html">
    type Description = Templating.Template<"templates\description.html">
    type ListGroup = Templating.Template<"templates\list-group.html">
    type ListGroup2 = Templating.Template<"templates\list-group-2.html">
    type Button = Templating.Template<"templates\\button.html">
    
    let Main =
        let insert doc =
            doc |> Doc.RunById "main"
        
        Hello.Doc()
        |> insert

        Ul.Doc(
            Links = [
                li [ text "Hello 1" ]
                li [ text "Hello 2" ]
            ]
        ) |> insert

        Description.Doc(
            Content = [ 
                p [ text "Something..." ]
            ]
        ) |> insert

        ListGroup.Doc(
            FirstBody = [ ListGroup.Item.Doc(Title = "First") ],
            SecondBody = [ ListGroup.Item.Doc(Title = "Second") ]
        ) |> insert

        ListGroup2.Doc(
            [
                ListGroup2.ListItem.Doc()
                ListGroup2.ListItem.Doc()
                ListGroup2.ActiveListItem.Doc()
            ]
        ) |> insert
        
        Button.Doc(
            Send = fun el ev -> ()
        ) |> insert