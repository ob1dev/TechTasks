# Deck of Cards

Card:
- Suit -> {Spade, Heart, Club, Diamond}
- Face/Value -> {Ace, 2-10, Jack, Queen, King}

Example: Ace of Spades, 2 of Diamonds

Deck:
- collection of (52) cards (every unique card)
- operations:
  - Card deal(); // remove the first/head of the deck
  - void returnCard(Card c); // add to the end/bottom of the deck
  - void shuffle(); // given a deck order, permute that order in an unbiased way. 

Questions:
1. What do your Card and Deck classes look like?
2. What data structure would you use for the collection of cards?
3. Let's implement Card/Deck (all operations)