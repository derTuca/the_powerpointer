// Write your Javascript code.
$(document).ready(function () {
    
    $("#audioTag").bind('durationchange',
        function(e) {
            if (this.duration !== Infinity) {
                $('#my-range').range({
                    min: 0,
                    max: $('#audioTag').prop("duration"),
                    start: 0,
                    step: 0.1,
                    onChange: function (val, meta) {
                        if (meta.triggeredByUser) {
                            $('#audioTag').prop("currentTime", val);
                        }


                    }
                });
            }
        });
    $('#audioTag').bind('timeupdate',
        function() {
            $('#my-range').range('set value', $('#audioTag').prop("currentTime"));
        });
    $('#user-details').popup({
        inline: true,
        hoverable: true
    });

    $('#playIcon').click(function () {
        if ($('#playIcon').hasClass('play')) {
            $('#audioTag').trigger("play");
            $('#playIcon').toggleClass('play pause');
        } else {
            $('#audioTag').trigger("pause");
            $('#playIcon').toggleClass('pause play');
        }
        
       
    });

    

    $.validator.addMethod("regex",
        function(value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
        },
        "Please check your input.");

    $('#registerForm').validate({
        rules: {
            Email: {
                required: true,
                email: true
                //remote: "/Account/EmailExists"  Am vise mari, da' treaba asta tare nu merge
            },
            Password: {
                required: true,
                minlength: 8
            },
            ConfirmPassword: {
                required: true,
                minlength: 8,
                equalTo: "#Password"
            },
            Name: {
                required: true,
                regex: /\w+\s\w+/
            }
            
        },
        messages: {
            Email: "Please enter a valid email address",
            Password: "Please enter a password at least 8 characters long",
            ConfirmPassword: "Please enter the same password as above"
        },
        errorPlacement: function(error, element) {
            error.addClass("error");
            error.insertAfter(element.parent());
        },
        highlight: function(element, errorClass, validClass) {
            $(element).parents(".field").addClass(errorClass);
        },
        unhighlight: function(element, errorClass, validClass) {
            $(element).parents(".field").removeClass(errorClass);
        }
    });


    
});


function starClicked(icon, id) {
    console.log(id);
    $.get("/api/favorite",
        { id: id },
        function(result) {
            if (result) {
                icon.classList.remove('empty');
            } else icon.classList.add('empty');
        }).fail(function(e) {
        console.log(e);
    });
}

var showMoreAudio;
function songPlayShowMoreClicked(link) {

    showMoreAudio = document.createElement('audio');
    showMoreAudio.setAttribute('src', "/media/songs/" + link);
    showMoreAudio.play();
}

var set = true;
var currentDiv;
var prevWasGray = false;
function songClicked(id, div) {

    $.ajax({
        type: "GET",
        url: "/Shared/GetSong/" + id,
        datatype: "html",
        success: function(data) {
            if (currentDiv !== null) {
                var c = prevWasGray ? 'lightgray' : 'white';
                $(currentDiv).css('background-color', c);
            }

            //de ce nu poate sa accepte lightgray nu inteleg
            prevWasGray = $(div).css('background-color') === 'rgb(211, 211, 211)';
            $(div).css('background-color', 'lightblue');
            currentDiv = div;
            $('#showSongsPlayer').html(data);
        }
    });
   
}

function clickedPlayOnShowSongs() {
    var icon = document.getElementById("showSongsPlayIcon");
    if (icon.classList.contains('pause')) {
        $('#showSongsAudio').trigger('pause');
        icon.classList.remove('pause');
        icon.classList.add('play');
    } else {
        $('#showSongsAudio').trigger('play');
        icon.classList.remove('play');
        icon.classList.add('pause');
    }

}

function getTimeStringFromSeconds(time) {
    var minutes = Math.floor(time / 60);
    return minutes + ":" + Math.floor(time - 60 * minutes);
}


function profilePictureSelected() {
    document.getElementById("profilePictureForm").submit();
}