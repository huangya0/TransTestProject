//-----------------

var hostname = '127.0.0.1', //'192.168.1.2',
    port = 8083,
    // userName = 'mao2080',
    // password = '123',
    mqttClientId = 'client-cs2019',
    timeout = 5,
    keepAlive = 100,
    cleanSession = false,
    ssl = false;
mqttClient = new Paho.MQTT.Client(hostname, port, mqttClientId);

//建立客户端实例
var options = {
    invocationContext: {
        host: hostname,
        port: port,
        path: mqttClient.path,
        clientId: mqttClientId
    },
    timeout: timeout,
    keepAliveInterval: keepAlive,
    cleanSession: cleanSession,
    useSSL: ssl,
    // userName: userName,
    // password: password,
    reconnect: true,         // Enable automatic reconnect
    //reconnectInterval: 10,     // Reconnect attempt interval : 10 seconds
    //disconnectedPublishing : true,
    onSuccess: onConnect,
    onFailure: function (e) {
        console.log(e);
        s = "{time:" + new Date().Format("yyyy-MM-dd hh:mm:ss") + ", onFailure()}";
        console.log(s);
    }
};

//连接服务器并注册连接成功处理事件
function onConnect() {
    //debugger;
    console.log("onConnected");
    s = "{time:" + new Date().Format("yyyy-MM-dd hh:mm:ss") + ", onConnected()}";
    console.log(s);
    //订阅所有主题
    for (var i = 0; i < topicArray.length; i++)
        mqttClient.subscribe(topicArray[i]);
};

//debugger;
mqttClient.connect(options);

mqttClient.onConnectionLost = onConnectionLost;
//注册连接断开处理事件
mqttClient.onMessageArrived = onMessageArrived;

//注册消息接收处理事件
function onConnectionLost(responseObject) {
    debugger;
    console.log(responseObject);
    s = "{time:" + new Date().Format("yyyy-MM-dd hh:mm:ss") + ", onConnectionLost()}";
    console.log(s);
    if (responseObject.errorCode !== 0) {
        console.log("onConnectionLost:" + responseObject.errorMessage);
        console.log("连接已断开");
    }
};

//debugger;
//checkReconnect();
//定时检查状态并重连
function checkReconnect() {
        //window.mqttReconnect =
    window.setInterval(function ()
    {
        if (!mqttClient.isConnected.call())
        {
            debugger;
            var s = "{time:" + new Date().Format("yyyy-MM-dd hh:mm:ss") + ", checkReconnect()}";
            console.log(s);
            //mqttClient = null;
            //mqttClient = new Paho.MQTT.Client(hostname, port, mqttClientId);
            //options.mqttVersionExplicit = null;

            //delete options.mqttVersionExplicit;
            //delete options.mqttVersion;
            //if (mqttClient.disconnected != null) {
            //    mqttClient.disconnected();
            //}
            //options.cleanSession = true;

            //mqttClient.reset();
            //mqttClient.connect(options);
        }
    }, 5000);
};

Date.prototype.Format = function(fmt) { //author: meizz
    var o = {
        "M+": this.getMonth() + 1, //月份
        "d+": this.getDate(), //日
        "h+": this.getHours(), //小时
        "m+": this.getMinutes(), //分
        "s+": this.getSeconds(), //秒
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度
        "S": this.getMilliseconds() //毫秒
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1,
                (RegExp.$1.length == 1)
                ? (o[
                    k])
                : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};

