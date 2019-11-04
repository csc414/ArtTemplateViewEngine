const template = require('art-template');

module.exports = {
    render: function(callback, path, model) {
        var html = template(path, model);
        callback(null, html);
    }
};