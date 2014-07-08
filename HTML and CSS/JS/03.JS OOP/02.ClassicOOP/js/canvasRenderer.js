var canvasRenderer = function (canvasElementId) {
    var canvas = document.getElementById(canvasElementId);
    var ctx = canvas.getContext("2d");
	
    var drawLine = function (startX, startY, endX, endY, strokeColor ,lineWidth) {
        var lineWidth = lineWidth || 1;
        var strokeColor = strokeColor || 'black';
        ctx.beginPath();
        ctx.lineWidth = lineWidth;
        ctx.strokeStyle = strokeColor;
        ctx.moveTo(startX, startY);
        ctx.lineTo(endX, endY);
        ctx.stroke();
    }
	
    var drawCircle = function (x, y, radius, strokeColor, lineWidth , fillColor) {
        ctx.beginPath();
        var lineWidth = lineWidth || 1;
        var strokeColor = strokeColor || 'black';
        ctx.lineWidth = lineWidth;
        ctx.strokeStyle = strokeColor;
        ctx.arc(x, y, radius, 0, 2 * Math.PI);
        if (fillColor) {
            ctx.fillStyle = fillColor;
            ctx.fill();
        }

        ctx.stroke();
    }
	
    var drawRect = function (x, y, width , height , strokeColor, lineWidth, fillColor) {
        ctx.beginPath();
        var lineWidth = lineWidth || 1;
        var strokeColor = strokeColor || 'black';
        ctx.lineWidth = lineWidth;
        ctx.strokeStyle = strokeColor;
        ctx.rect(x, y, width , height);
        if (fillColor) {
            ctx.fillStyle = fillColor;
            ctx.fill();
        }

        ctx.stroke();
    }
	
    return {
        drawLine: drawLine,
        drawCircle: drawCircle,
        drawRect: drawRect
    }
}