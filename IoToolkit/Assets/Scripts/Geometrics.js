const UP = 0;
const LEFT = 90;
const DOWN = 180;
const RIGHT = 270;

function IsUp(rotation) {
    return rotation < LEFT || rotation > RIGHT;
}

function IsDown(rotation) {
    return !IsUp(rotation) && rotation != 90 && rotation != 270;
}

function IsRight(rotation) {
    return rotation > DOWN;
}

function IsLeft(rotation) {
    return !IsRight(rotation) && rotation != 0 && rotation != 180;
} 

function CalculateAxis(rotation){

    let x = 0;
    let y = 0;

    if(IsBetween(rotation, -22.5, 22.5)) {
        x = 0;
        y = 1;
    }

    if(IsBetween(rotation, 22.5, 67.5)) {
        x = -1;
        y = 1;
    }

    if(IsBetween(rotation, 67.5, 112.5)) {
        x = -1;
        y = 0;
    }

    if(IsBetween(rotation, 112.5, 157.5)) {
        x = -1;
        y = -1;
    }

    if(IsBetween(rotation, 157.5, 202.5)) {
        x = 0;
        y = -1;
    }

    if(IsBetween(rotation, 202.5, 247.5)) {
        x = 1;
        y = -1;
    }

    if(IsBetween(rotation, 247.5, 292.5)) {
        x = 1;
        y = 0;
    }

    if(IsBetween(rotation, 292.5, 337.5)) {
        x = 1;
        y = 1;
    }

    return {x: x, y: y};
}

function IsBetween(number,min,max) {
    return number >= min && number <= max;
}


function main(args){

    const rotation = args[2];

    console.log("UP is 0: ", IsUp(0));
    console.log("DOWN is 180: ", IsDown(180));
    console.log("LEFT is 90: ", IsLeft(90));
    console.log("RIGHT is 270: ", IsRight(270));


    console.log("\nROTATION CALC");
    console.log("--------------------------------------");

    console.log(`UP is ${rotation}: `, IsUp(rotation));
    console.log(`DOWN is ${rotation}: `, IsDown(rotation));
    console.log(`LEFT is ${rotation}: `, IsLeft(rotation));
    console.log(`RIGHT is ${rotation}: `, IsRight(rotation));
   
    console.log(CalculateAxis(rotation));
}

main(process.argv);