function insertDiv(content) {
  var newDiv = document.createElement("div");
  newDiv.innerHTML = content;
  document.body.appendChild(newDiv);
}

//Task one
insertDiv("Task One:");
var text = 'reverse me';
insertDiv(text.split('').reverse().join(''));

//Task two
insertDiv("Task Two:");

var brackets = '((a+b)/5-d)';

function checkBrackets(string) {
  var numberOfOpenBrackets = 0;
  for (var i = 0; i < string.length; i++) {
    if (string[i] === '(') {
      numberOfOpenBrackets++;
    } else if (string[i] === ')') {
      numberOfOpenBrackets--;
    }

    if (numberOfOpenBrackets < 0) {
      return false;
    }
  }

  return numberOfOpenBrackets === 0;
}

insertDiv("The brackets in " + brackets + " are correct: " + checkBrackets(brackets));


//Task three
insertDiv("Task three");

function countRepeatingSubstring(text, word) {
  var match = text.match(new RegExp(word, 'gi'));

  return match.length || 0;
}

var findIn = "We are liv<b>in</b>g in an yellow submar<b>in</b>e. We don't have anyth<b>in</b>g else. Inside the submar<b>in</b>e is very tight. So we are dr<b>in</b>k<b>in</b>g all the day. We will move out of it in 5 days.";

insertDiv(countRepeatingSubstring(findIn, 'in'));

//Task Four
insertDiv("Task Four:");

function toMixCase(str) {
  var replaced = '';

  for (var i = 0; i < str.length; i++)
    replaced += str.charAt(i)[Math.round(Math.random()) ? 'toLowerCase' : 'toUpperCase']();

  return replaced;
}

function changeText(str) {
  return str.replace(/<upcase>(.*?)<\/upcase>/g, function(match, p1) {
    return p1.toUpperCase();
  }).replace(/<lowcase>(.*?)<\/lowcase>/g, function(match, p1) {
    return p1.toLowerCase();
  }).replace(/<mixcase>(.*?)<\/mixcase>/g, function(match, p1) {
    return toMixCase(p1);
  });
}


var tagsToReplace = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don\'t</mixcase> have <lowcase>ANYTH<mixcase>living</mixcase>ING</lowcase> else.';

insertDiv(changeText(tagsToReplace));

//Task Five
insertDiv("Task Five:");

function replaceSpaces(text) {
  return text.replace(/ /g, '&nbsp;');
}

insertDiv(replaceSpaces('  hello    world '));

//Task Six
insertDiv("Task Six:");

function removeTags(text) {
  return text.replace(/<.+?>/g, '');
}

var textWithTags = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";
insertDiv(removeTags(textWithTags));

//Task Seven
insertDiv("Task Seven:");

var url = 'http://www.devbg.org/forum/index.php';

function parseUrl(url) {
  var regex = /(.+?):\/\/(.+?)(\/.+)/g;
  var match = regex.exec(url);
  return {
    protocol: match[1],
    server: match[2],
    resource: match[3]
  };
}

var urlObj = parseUrl(url);
for (var prop in urlObj) {
  insertDiv(prop + " : " + urlObj[prop]);
}

//Task Eight
insertDiv("Task Eight:");

var htmlWithATags = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p> ';

function replaceLinkTags(html) {
  var linkRegex = /<a href="(.+?)>/g;

  return html.replace(linkRegex, function(match, p1) {
    return "[URL=" + p1 + "]";
  }).replace(/<\/a>/g, '[/URL]');
}

insertDiv(replaceLinkTags(htmlWithATags));

//Task Nine
insertDiv("Task Nine:");

var strWithEmails = 'Nakov: nakov@telerik.com, Pesho : pesho@gmail.com';
insertDiv(strWithEmails.match(/\w+@\w+\.\w+/g).join(", "));

//Task Ten
insertDiv("Task Ten:");

function isPalindrome(str) {
  for (var i = 0; i < parseInt(str.length / 2); i++) {
    if (str[i] !== str[str.length - 1 - i]) {
      return false;
    }
  }

  return true;
}

var strWithPalindromes = 'Static void Main() ABBA, using System lamal, exe.';

insertDiv(strWithPalindromes.match(/\w+/g).filter(function(word) {
  return isPalindrome(word);
}).join(", "));

//Task Evelen
insertDiv("Task Evelen:");

function stringFormat(str) {
  var selfArguments = arguments;

  return str.replace(/\{(\d+)\}/g, function(match, p1) {
    return selfArguments[parseInt(p1) + 1];
  });
}

var frmt = '{0}, {1}, {0} text {2}';
var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');

insertDiv(str);

//Task Twelve
insertDiv("Task Twelve:");

var template = "<strong>-{name}-</strong> <span>-{age}-</span>";
var people =
  [{
    name: 'Peter',
    age: 14
  }, {
    name: 'Ivan',
    age: 18
  }, {
    name: 'Vlado',
    age: 17
  }, {
    name: 'Joro',
    age: 25
  }];

function generateList(people, template) {
  var result = '<ul>';

  people.forEach(function(human) {
    result += '<li>';

    result += template.replace(/-\{(.*?)\}-/g, function(match, p1) {
      return human[p1];
    });

    result += '</li>';
  });

  result += '</ul>';

  return result;
}

var peopleList = generateList(people, template);
insertDiv(peopleList);
