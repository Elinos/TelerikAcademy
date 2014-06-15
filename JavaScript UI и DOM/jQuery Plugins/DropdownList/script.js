$.fn.dropdown = function () {
    var optionMenu = $(this);
    optionMenu.css('display' , 'none');
    var currentSelection = $('<div/>').text(optionMenu.children('option').first().text()).attr('id', 'current');
    currentSelection.on('click', function () {
        if (dropdownUL.css('display') === 'block') {
            dropdownUL.css('display', 'none');
        } else {
            dropdownUL.css('display', 'block');
        }
    });
    var contentDiv = $('<div/>').addClass('dropdown-list-options');
    var dropdownUL = $('<ul/>').css('display','none');
    var option = optionMenu.children('option');
    option.each(function () {
        var dateValueIndex = $(this).val();
        var li = $('<li/>').addClass("dropdown-list-option")
                           .attr('data-value', dateValueIndex)
                           .text($(this).text())
                           .on('click', function () {
                               optionMenu.find("option:selected").removeAttr("selected");
                               optionMenu.find('option[value="' + dateValueIndex + '"]').attr("selected","true");
                               currentSelection.text($(this).text());
                               dropdownUL.css('display', 'none');
                           })
                           ;
        dropdownUL.append(li);
    });
    contentDiv.append(currentSelection);
    contentDiv.append(dropdownUL);
    $('body').append(contentDiv);

};
        $('#dropdown').dropdown();
