window.onload = function() {
    var stage,
        stageWidth = 1000,
        padding = {
            x: 20,
            y: 10
        },
        borderColor = 'yellowgreen',
        familyLayer,
        familyMembers = [{
            mother: 'Maria Petrova',
            father: 'Georgi Petrov',
            children: ['Teodora Petrova',
                'Peter Petrov'
            ]
        }, {
            mother: 'Petra Stamatova',
            father: 'Todor Stamatov',
            children: ['Maria Petrova']
        }];


    Array.prototype.remove = function(from, to) {
        var rest = this.slice((to || from) + 1 || this.length);
        this.length = from < 0 ? this.length + from : from;
        return this.push.apply(this, rest);
    };

    function FamilyMember(x, y, name) {
        this.x = x,
        this.y = y,
        this.name = name,
        this.gender = this.name.substr(this.name.length - 1) === 'a' ? "female" : "male",
        this.renderedName = new Kinetic.Text({
            x: x + padding.x,
            y: y + padding.y,
            text: this.name,
            fontSize: 20,
            fontFamily: 'Calibri',
            fill: 'black'
        }),
        this.width = this.renderedName.width(),
        this.height = this.renderedName.height(),
        this.draw = function() {
            rect = new Kinetic.Rect({
                x: x,
                y: y,
                stroke: borderColor,
                strokeWidth: 2,
                fill: 'white',
                width: this.renderedName.width() + padding.x * 2,
                height: this.renderedName.height() + padding.y * 2,
                cornerRadius: this.gender === "female" ? this.height / 2 + padding.y : 10
            });

            familyLayer.add(rect);
            familyLayer.add(this.renderedName);
        };
    }

    function drawConnection(stX, stY, eX, eY) {
        var beizerCPdY = Math.abs(eY - stY) * 0.75;
        var currLine = new Kinetic.Shape({
            drawFunc: function(context) {
                context.beginPath();
                context.moveTo(stX, stY);
                context.bezierCurveTo(stX, stY + beizerCPdY,
                    eX, eY - beizerCPdY,
                    eX, eY);
                context.strokeShape(this);
                context.beginPath();
                context.lineTo(eX + 5, eY - 5);
                context.lineTo(eX - 5, eY - 5);
                context.lineTo(eX, eY);
                context.fillShape(this);
            },
            strokeWidth: 1,
            fill: '#77B300',
            stroke: '#77B300'
        });

        familyLayer.add(currLine);
    }

    function maxPath(member) {
        if (!member.children || member.children.length === 0) {
            return 0;
        }
        var longestPath = 0;
        for (var i = 0, len = member.children.length; i < len; i++) {
            longestPath = Math.max(longestPath, maxPath(member.children[i]));
        }
        return longestPath + 1;
    }

    function indexOfParent(name, familyMembers) {
        for (var i = 0; i < familyMembers.length; i++) {
            if (name[name.length - 1] === 'a') {
                if (familyMembers[i].mother === name) {
                    return i;
                }
            } else {
                if (familyMembers[i].father === name) {
                    return i;
                }
            }
        }
        return -1;
    }

    function replaceChildrens() {
        for (var i = 0; i < familyMembers.length; i++) {
            var currentMember = familyMembers[i];
            if (currentMember.children.length) {
                for (var c = 0; c < currentMember.children.length; c++) {
                    var index = indexOfParent(currentMember.children[c], familyMembers);
                    if (index >= 0) {
                        currentMember.children[c] = familyMembers[index];
                        familyMembers.remove(index);
                    }
                }
            }
        }
    }

    replaceChildrens();
    var levels = 0;
    for (var i = 0; i < familyMembers.length; i++) {
        levels = Math.max(maxPath(familyMembers[i]) + 1, levels);
    }

    stage = new Kinetic.Stage({
        container: 'container',
        width: stageWidth,
        height: levels * 80 + 100,
    });

    familyLayer = new Kinetic.Layer();

    function drawLevel(array, level) {
        if (!array) {
            return;
        }
        for (var i = 0; i < array.length; i++) {
            if (array[i].father && array[i].mother) {
                var father = new FamilyMember(100, 100 * level, array[i].father);
                var mother = new FamilyMember(300, 100 * level, array[i].mother);
                father.draw();
                drawConnection(father.x + father.width / 2 + padding.x,
                    father.y + father.height + padding.y * 2,
                    father.x + 200 + father.width / 2 + padding.x,
                    father.y + 100);
                mother.draw();
                drawConnection(mother.x + mother.width / 2 + padding.x,
                    mother.y + mother.height + padding.y * 2,
                    mother.x + mother.width / 2 + padding.x,
                    mother.y + 100);
            } else {
                var person = new FamilyMember(300 - 200 * i, 100 * level, array[i]);
                person.draw();
            }

            if (!array[i] || !array[i].children) {
                continue;
            }
            drawLevel(array[i].children, level + 1);
        }
    }
    drawLevel(familyMembers, 1);
    stage.add(familyLayer);
};
