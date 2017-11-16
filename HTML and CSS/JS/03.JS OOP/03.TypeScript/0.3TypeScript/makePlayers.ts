var newPlayer = new Player.Player('Playercho');

var guardian = new Hero.Hero("Geroicho", new Races.HumanRace(), new Classes.GuardClass());
console.log("Only the hero:" + guardian.name);
console.log(guardian.toString());

var assassin = new Hero.Hero("Geroika", new Races.ElfRace(), new Classes.AssassinClass());
console.log("Only the hero:" + assassin.name);
console.log(guardian.toString());


newPlayer.addHero(guardian);
newPlayer.addHero(assassin);

console.log("Player " + newPlayer.username + " and his heroes:");
console.log(newPlayer.toString());

// add more than 3 champs
var assassin2 = new Hero.Hero("Geroika2", new Races.ElfRace(), new Classes.AssassinClass());
var assassin3 = new Hero.Hero("Geroika2", new Races.ElfRace(), new Classes.AssassinClass());

newPlayer.addHero(assassin2);
// newPlayer.addHero(assassin3); // this line will make an error because the max number of heroes is reached

GM.GM.giveSlotToPlayer(newPlayer);

newPlayer.addToBalance(100);
GM.GM.giveSlotToPlayer(newPlayer);
// now check the console end enter the promo code there!! like so 
// newPlayer.addHeroSlot("3di");

// the code will be different every time you type GM.GM.giveSlotToPlayer(newPlayer);

// newPlayer.addHero(assassin3); // now if you have entered the code correctly and you do this line, you will add another hero to the player
// and if you try to add another hero the system will throw exception that the maximum number of heroes is reached again :)