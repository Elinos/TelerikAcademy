var formidable = require('formidable'),
  http = require('http'),
  url = require("url"),
  path = require("path"),
  fs = require('fs');

http.createServer(function(req, res) {
  if (req.url == '/upload' && req.method.toLowerCase() == 'post') {
    var form = new formidable.IncomingForm();
    if (!fs.existsSync("uploads")) {
      fs.mkdirSync("uploads", 0766, function(err) {
        if (err) {
          console.log(err);
          res.send("ERROR! Can't make the directory! \n");
        }
      });
    }
    form.uploadDir = "./uploads";
    form.keepExtensions = true;

    form.parse(req, function(err, fields, file) {
      var link = 'http://localhost:3000/uploads/' + file.upload.path.substring(8);
      res.writeHead(200, {
        "Content-Type": "text/html"
      });
      res.write('You can download you file @ <a href="' + link + '">' +
        link + '</a>');
      res.end();
    });
  } else {
    var uri = url.parse(req.url).pathname,
      filename = path.join(process.cwd(), uri);

    fs.exists(filename, function(exists) {
      if (!exists) {
        res.writeHead(404, {
          "Content-Type": "text/plain"
        });
        res.write("404 Not Found\n");
        res.end();
        return;
      }

      if (fs.statSync(filename).isDirectory()) filename += '/index.html';

      fs.readFile(filename, "binary", function(err, file) {
        if (err) {
          res.writeHead(500, {
            "Content-Type": "text/plain"
          });
          res.write(err + "\n");
          res.end();
          return;
        }

        res.writeHead(200);
        res.write(file, "binary");
        res.end();
      });
    });
  }
}).listen(3000);
console.log('Server running on port 3000');
