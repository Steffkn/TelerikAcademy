(function (){
	var animals = [{
		name: 'Bear',
		ofClass: 'Mammalia',
		legs: 4
	},{
		name: 'Dog',
		ofClass: 'Mammalia',
		legs: 4
	},{
		name: 'Turtle',
		ofClass: 'Reptilia',
		legs: 4
	},{
		name: 'Centipede',
		ofClass: 'Arthropods',
		legs: 100
	},{
		name: 'Crocodile',
		ofClass: 'Reptilia',
		legs: 4
	},{
		name: 'Frog',
		ofClass: 'Amphibian',
		legs: 4
	},{
		name: 'Viper',
		ofClass: 'Reptilia',
		legs: 0
	},{
		name: 'Earthworm',
		ofClass: 'Annelida',
		legs: 0
	},{
		name: 'Python',
		ofClass: 'Reptilia',
		legs: 4
	},{
		name: 'Black Widow',
		ofClass: 'Arachnida',
		legs: 8
	},{
		name: 'SpiderMan',
		ofClass: 'Mammalia',
		legs: 2
	},{
		name: 'Mosquito',
		ofClass: 'Insecta',
		legs: 6
	},{
		name: 'Bee',
		ofClass: 'Insecta',
		legs: 6
	},{
		name: 'Gorilla',
		ofClass: 'Mammalia',
		legs: 2
	},{
		name: 'Goose',
		ofClass: 'Aves',
		legs: 2
	},{
		name: 'Emu',
		ofClass: 'Aves',
		legs: 2
	},{
		name: 'Penguin',
		ofClass: 'Aves',
		legs: 2
	},{
		name: 'Bat',
		ofClass: 'Mammalia',
		legs: 2
	},{
		name: 'Whale',
		ofClass: 'Mammalia',
		legs: 0
	},{
		name: 'Kangaroo',
		ofClass: 'Mammalia',
		legs: 2
	},{
		name: 'Shark',
		ofClass: 'Fish',
		legs: 0
	},{
		name: 'Carp',
		ofClass: 'Fish',
		legs: 0
	},{
		name: 'Catfish',
		ofClass: 'Fish',
		legs: 0
	},{
		name: 'Eel',
		ofClass: 'Fish',
		legs: 0
	},{
		name: 'Salmon',
		ofClass: 'Fish',
		legs: 0
	},{
		name: 'Octopus',
		ofClass: 'Mollusc',
		legs: 6
	},{
		name: 'Blue Crab',
		ofClass: 'Crustacean',
		legs: 8
	}]
	
    var groupedAnimals = _.groupBy(_.sortBy(animals, 'legs'), 'ofClass');
	console.log(groupedAnimals);
	
	// i have some animals with no legs.. hope that's not a problem
	var totalLegs = 0;
	_.chain(animals)
		.each(function(animal){totalLegs += animal.legs;})
		console.log('total legs: ' + totalLegs);
		
	
}());