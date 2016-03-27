function run_waitMe() {
    $('#waitme').waitMe({
        effect: 'bounce',
        text: '正在上传。。。',
        bg: 'rgba(0,0,0,0.7)',
        color: '#fff',
        sizeW: '8',
        sizeH: '8',
        source: 'img.svg'
    });
}

function close_waitMe() {
    $('#waitme').waitMe('hide');
}
function update_waitMe_percent(percent) {
    $(".waitpercent").html(percent + "%");
}

                
                
                          
           