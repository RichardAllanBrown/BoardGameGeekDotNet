BoardGameGeekDotNet
===================

Introduction
------------

This is a .NET library that aims to help developers intergrate the BoardGameGeek API.  Simply pull into your project and the client object will give you simple methods to use.  I've created this to help with the construction of future websites I have planned and to also get more people building cool apps for a great hobby!

See http://www.boardgamegeek.com/xmlapi for more info on the API I am using to create this.

Current Functionality
---------------------

- Search
- Search with settings
- Retrieve boardgame(s)
- Retrieve boardgame(s) with settings
- Retrieve GeekList
- Retrieve GeekList with settings


Future Functionality
--------------------

- Retrieve forum posts
- Retrieve forum posts with settings
- Retrieve users games
- Retrieve users games with settings

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
GeekList geekList = client.getGeekList(22564);

//Search for games using a string
List<CollectionItem> collection = client.getUserCollection("Rokusho");

```
