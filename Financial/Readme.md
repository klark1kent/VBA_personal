## Financial
<br/>

For the *SUMPRODUCT* formula in SumProductCountAndSum.xlsx. <br />
It looks like this:<br/>

--------
=SUMPRODUCT((B2:B6=C2)*1)<br />
+SUMPRODUCT((B8:B13=C8)*1)<br />
+SUMPRODUCT((B16:B20=C16)*1)<br />

--------

=SUMPRODUCT(((B2:B6=C2)*1)*(A2:A6=D2))<br />
+SUMPRODUCT(((B8:B13=C8)*1)*(A8:A13=D8))<br />
+SUMPRODUCT(((B16:B20=C16)*1)*(A16:A20=D16))<br />

--------
 
![Screenshot is here](https://image.ibb.co/nJ9WaF/Paint.png)

<br/>
Array formula:
Which value in array is found in a range? 

=INDEX(C1:C6,MATCH(TRUE,COUNTIF(D:D,C1:C6)>0,0))


![Screenshot is here](http://image.ibb.co/nhsuZv/vlookup.png)
