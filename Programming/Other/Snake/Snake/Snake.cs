using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

class Snake
{
    private Queue<Element> snakeElements;
    private List<Element> directions;
    private static int direction = 1; //at first snake moves to the right
    private Element newSnakeElement; //the head of the snake

    public Snake()
    {
        SetDefaultSnakeSize();
        SetAvailableDirections();
        Display();
    }

    public Snake(Queue<Element> snakeElements)
    {
        this.snakeElements = snakeElements;
        SetAvailableDirections();
        Display();
    }

    private void SetDefaultSnakeSize()
    {
        int startX = (Console.WindowWidth / 2) - 3;
        int startY = Console.WindowHeight / 2;

        snakeElements = new Queue<Element>();
        for (int i = 0; i < 5; i++)
        {
            snakeElements.Enqueue(new Element(startY, startX + i, '#'));
        }
    }

    private void SetAvailableDirections()
    {
        directions = new List<Element>();
        directions.Add(new Element(0, -1)); //move left
        directions.Add(new Element(0, 1)); //move right
        directions.Add(new Element(-1, 0)); //move up 
        directions.Add(new Element(1, 0)); //move down
    }

    private void Display()
    {
        try
        {
            foreach (Element element in snakeElements)
            {
                Console.SetCursorPosition(element.col, element.row);
                Console.Write(element.symbol);
            }
        }
        catch (ArgumentException)
        {
            throw new GameException();
        }
        
    }

    public void Move()
    {
        //adding the new element
        Element snakeHead = snakeElements.Last();
        Element nextElement = directions[direction];
        newSnakeElement = new Element(snakeHead.row + nextElement.row, snakeHead.col + nextElement.col, snakeHead.symbol);
        snakeElements.Enqueue(newSnakeElement);
        Display();
    }

    // get current direction of the snake
    public int GetCurrentDirection()
    {
        return direction;
    }

    // set the direction of the snake
    public void SetCurrentDirection(int dir)
    {
        direction = dir;
    }

    public Element GetSnakeHead()
    {
        return newSnakeElement;
    }

    public List<Element> GetSnakeElements()
    {
        List<Element> snakeParts = new List<Element>();
        foreach (Element element in snakeElements)
        {
            snakeParts.Add(element);
        }
        return snakeParts;
    }

    public void RemoveSnakeTail()
    {
        //empty space to avoid Console.Clear() method.
        Element elementToRemove = snakeElements.Dequeue();
        Console.SetCursorPosition(elementToRemove.col, elementToRemove.row);
        Console.Write(" ");
    }

}

