$(function() {
    $('.save-hours').on('click', function() {
        savePayPeriod($(this).closest('.row'));
    });
});

function selectYear(selected) {
    var data = {
        year: $(selected).text()
    };

    alert(data.year);

    $.ajax({
        url: 'PTO/LoadYear',
        type: 'POST',
        data: data
    }).done(function (response) {
        alert(response);
        //$('.color').find('[value="' + data.OriginalDisplayName + '"]').remove();
        //self.resetInputs();
        //$('.modal [data-content="delete_color"] .confirm_question').addClass('hidden');
        //$('.actions .cancel, .actions .delete_color_confirm').addClass('hidden');
        //$('.success').removeClass('hidden');
        //$('.close_modal').removeClass('hidden');
        //$('.modal [data-content="delete_color"] .close_modal').removeClass('hidden');
        //$('.color').val(-1);
    }).fail(function () {
        alert('Sorry, load failed!');
    });
}

function savePayPeriod(target) {
    var data = {
        Id: target.attr('data-unique-id'),
        Hours: target.find('.planned').val(),
        Comments: target.find('.comment-box').val()
    };
    //console.log(data.id + " " + data.hours + " " + data.comment);

    $.ajax({
        url: 'PTO/SaveEntry',
        type: 'POST',
        data: data
    }).done(function (response) {
        alert(response);
        //$('.color').find('[value="' + data.OriginalDisplayName + '"]').remove();
        //self.resetInputs();
        //$('.modal [data-content="delete_color"] .confirm_question').addClass('hidden');
        //$('.actions .cancel, .actions .delete_color_confirm').addClass('hidden');
        //$('.success').removeClass('hidden');
        //$('.close_modal').removeClass('hidden');
        //$('.modal [data-content="delete_color"] .close_modal').removeClass('hidden');
        //$('.color').val(-1);
    }).fail(function () {
        alert('Sorry, save failed!');
    });

}