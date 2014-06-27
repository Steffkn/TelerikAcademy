window.onload = function () {
    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1000,
        height: 600
    });
    var layer = new Kinetic.Layer();

    var imageObj = new Image();
    imageObj.onload = function () {
        var mario = new Kinetic.Sprite({
            x: 250,
            y: 535,
            image: imageObj,
            animation: 'idle',
            animations: {
                idle: [
                    // x, y, width, height (4 frames)
                  116, 4, 14, 30,
                  136, 4, 16, 30,
                  156, 4, 16, 30,
                  136, 4, 16, 30,
                ]
            },
            frameRate: 4,
            frameIndex: 0
        });

        layer.add(mario);

        stage.add(layer);

        mario.start();
    };

    imageObj.src = '../images/SuperMarioAllStarSheet3.gif';
}