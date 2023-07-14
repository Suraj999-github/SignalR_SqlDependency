"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
	connection.start().then(function () {
		alert('Connected to dashboardHub');
		InvokeProducts();
	}).catch(function (err) {
		return console.error(err.toString());
	});
});

function InvokeProducts() {
	connection.invoke("SendProducts").catch(function (err) {
		alert('1');
		return console.error(err.toString());
	});
}
connection.on("ReceivedProducts", function (products) {	
	alert(products);
});