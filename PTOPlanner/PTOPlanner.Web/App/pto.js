﻿$(function() {
    $('.save-hours').on('click', function() {
        savePayPeriod($(this).closest('.row'));
    });

    selectYear($('.active'));
});

function selectYear(selected) {

    
    $('.records').empty();

    var data = {
        year: $(selected).text()
    };
    console.log(selected)
    $.ajax({
        url: 'PTO/LoadYear',
        type: 'POST',
        data: data
    }).done(function (response) {
        var html = ''
        $(response.Data).each(function () {
            var comments = this.comments || '';
            var requested = this.RequestedHours || '';
            html += '<div class="row" data-unique-id="' + this.EmployeePTOBalanceID + '">';
            html += '<div class="col-xs-2">' + this.WeekEnding + '</div>';
            html += '<div class="col-xs-2 balance">' + this.PTOBalance + '</div>';
            html += '<div class="col-xs-2"><input type="text" class="planned" placeholder="[Enter in Hours]" value="' + comments + '"/></div>';
            html +=
                '<div class="col-xs-5"><input type="text" class="comment-box" placeholder="[Enter options comments]" val="' +
                requested +
                '"/></div>';
            html +=
                '<div class="col-xs-1"><button class="btn btn-default save-hours" type="button"><span class="glyphicon glyphicon-ok" title="Apply Changes"></span>Save</button>';
            html += '</div></div>';
        });
       
        $('.records').append(html);
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
        $(response.Data).each(function() {
            $('[data-unique-id="' + this.EmployeePTOBalanceID + '"]').find('.balance').text(this.PTOBalance);
        });
    }).fail(function () {
        alert('Sorry, save failed!');
    });

}