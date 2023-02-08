using System;
using System.Collections.Generic;

namespace LunarExplorer.Model;

public partial class Rover
{
    public long Id { get; set; }

    public long? XCord { get; set; }

    public long? YCord { get; set; }

    public string? Orient { get; set; }

    public string? Directions { get; set; }

    public Rover(long? XCord, long? YCord, string? Orient, string? Directions)
    {
        this.XCord = XCord;
        this.YCord = YCord;
        this.Orient = Orient;
        this.Directions = Directions;
    }


    private void turnLeft()
    {
        switch (this.Orient)
        {
            case "N":
                this.Orient = "W";
                break;
            case "E":
                this.Orient = "N";
                break;
            case "S":
                this.Orient = "E";
                break;
            case "W":
                this.Orient = "S";
                break;
            default:
                break;
        }
    }

    private void turnRight()
    {
        switch (this.Orient)
        {
            case "N":
                this.Orient = "E";
                break;
            case "E":
                this.Orient = "S";
                break;
            case "S":
                this.Orient = "W";
                break;
            case "W":
                this.Orient = "N";
                break;
            default:
                break;
        }
    }

    private void move(long? Xmax, long? Ymax)
    {
        switch (this.Orient)
        {
            case "N":
                if (this.YCord <= Ymax)
                {
                    this.YCord += 1;
                }
                break;
            case "E":
                if (this.XCord <= Xmax)
                {
                    this.XCord += 1;
                }
                break;
            case "S":
                if (this.YCord >= 0)
                {
                    this.YCord -= 1;
                }
                break;
            case "W":
                if (this.XCord >= 0)
                {
                    this.XCord -= 1;
                }
                break;
            default:
                break;
        }

    }

    public string moveRover(long? Xmax, long? Ymax, List<int[]> constriant)
    {
        long? XCord = this.XCord;
        long? YCord = this.YCord;
        for (int k = 0; k < this.Directions.Length; k++)
        {
            string d = this.Directions[k].ToString().ToUpper();
                    if(this.YCord > Ymax)
                    {
                        return $"{this.XCord} {this.YCord} {this.Orient} Rover Stopped! it has reached the maximum length of the plateau";
                        
                    }
                    else if(this.XCord > Xmax)
                    {
                        return $"{this.XCord} {this.YCord} {this.Orient} Rover Stopped! it has reached the maximum breadth of the plateau";
                        
                    }
                    else if(this.YCord < 0)
                    {
                        return $"{this.XCord} {this.YCord} {this.Orient} Rover Stopped! it has reached the minimum length of the plateau";
                        
                    }
                    else if(this.XCord < 0)
                    {
                        return $"{this.XCord} {this.YCord} {this.Orient} Rover Stopped! it has reached the minimum breadth of the plateau";   
                    }
                    else if (constriant.Count > 0)
                    {
                        for (int i = 0; i < constriant.Count; i++)     
                            {
                                if(this.XCord == constriant[i][0] && this.YCord == constriant[i][1] )
                                {
                                   
                                    return $"{this.XCord} {this.YCord} {this.Orient} Rover Stopped! it has collided with another rover";
                        
                                }
                               
                            }
                          
                    }
            switch (d)
            {
                case "R":
                    this.turnRight();
                    break;
                case "L":
                    this.turnLeft();
                    break;
                case "M":
                    this.move(Xmax, Ymax);
                    break;
                default:
                    break;
            }
        }

        return $"{this.XCord} {this.YCord} {this.Orient}";
    }
}

