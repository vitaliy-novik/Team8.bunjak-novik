var dropZone;
var file;

// Initializes the dropZone
$(document).ready(function () {
    dropZone = $('#dropZone');
    dropZone.removeClass('error');

    // Check if window.FileReader exists to make 
    // sure the browser supports file uploads
    if (typeof(window.FileReader) == 'undefined') {
        dropZone.text('Browser Not Supported!');
        dropZone.addClass('error');
        return;
    }

    // Add a nice drag effect
    dropZone[0].ondragover = function () {
        dropZone.addClass('hover');
        return false;
    };

    // Remove the drag effect when stopping our drag
    dropZone[0].ondragend = function () {
        dropZone.removeClass('hover');
        return false;
    };

    // The drop event handles the file sending
    dropZone[0].ondrop = function(event) {
        // Stop the browser from opening the file in the window
        event.preventDefault();
        dropZone.removeClass('hover');

        // Get the file and the file reader
        file = event.dataTransfer.files[0];
// Send the file
var xhr = new XMLHttpRequest();
var data = new FormData;
data.append("image", file);
        xhr.open('POST', '/Profile/UploadFiles', true);
        xhr.send(data);
    };
});

// Show the upload progress
function uploadProgress(event) {
    var percent = parseInt(event.loaded / event.total * 100);
    $('#dropZone').text('Uploading: ' + percent + '%');
}

// Show upload complete or upload failed depending on result
function stateChange(event) {
    if (event.target.readyState == 4) {
        if (event.target.status == 200) {
            $('#photo').text('Upload Complete!');
        }
        else {
            dropZone.text('Upload Failed!');
            dropZone.addClass('error');
        }
    }
}