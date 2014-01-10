<?php

class Animal
{
	public function WhatYouEat()
	{
		echo 'what i want';
	}
}

class Human extends Animal
{
	public function WhatYouEat()
	{
		return parent::WhatYouEat();
	}
}

$human = new Human();

echo $human->WhatYouEat();