BoardGameGeekDotNet
===================

Introduction
------------

This is a .NET library that aims to help developers intergrate the BoardGameGeek API.  Simply pull into your project and the client object will give you simple methods to use.  I've created this to help with the construction fo future websites I have planned and to also get more people building cool apps for a great hobby!

See http://www.boardgamegeek.com/xmlapi for more info on the library I'm creating.

Current Functionality
---------------------

- Search
- Search with params
- Retreive boardgame(s)
- Retreive boardgame(s) with params
- Retreive GeekList
- Retreive GeekList with params


Future Functionality
--------------------

- Retreive forum posts
- Retreive forum posts with params
- Retreive users games
- Retreive users games with params

How To Use
----------

```C#
//Create a client object
IBGGClient client = new BGGXMLClient();

//Search for games using string
List<BGSearchResult> result = client.searchBoardGame("7 Wonders");

//Retrieve boardgame(s) by their ID
List<BoardGame> boardGameDetals = client.getBoardGame(22334, 12343, 9873);

//Fetch a GeekList by it's ID
GeekList geekList = client.getGeekList(22564)

```
