 # TaxCalculatorDemo
 This is test demo project.
 Using .Net core 3.1
		    SQLite
        swagger
        Logger
		
 The data bellow are some sample data for getting started quicly.
 
//********Sample data for Municapility creation******\\
 
 {
    "id": 1,
    "name": "Vilinus",
    "taxRule": 2
  },
    {
    "id": 2,
    "name": "Kaunas",
    "taxRule": 1
  }

//********Sample data for Calculation rule 1******\\
{
  "id": 1,
  "name": "Calculation by adding up",
  "taxPeriods": [
    {
      "id": 1,
      "type": 1,
      "fromDate": "2020-01-01T00:00:00.000Z",
      "tillDate": "2020-12-31T00:00:00.000Z",
      "taxRate": 0.3,
      "dates": []
    },
    {
      "id": 2,
      "type": 2,
      "fromDate": "2020-01-01T00:00:00.000Z",
      "tillDate": "2020-01-31T00:00:00.000Z",
      "taxRate": 0.2,
      "dates": []
    },
    {
      "id": 3,
      "type": 3,
      "fromDate": "2020-01-06T00:00:00.000Z",
      "tillDate": "2020-01-12T00:00:00.000Z",
      "taxRate": 0.1,
      "dates": []
    }
  ]
}



//********Sample data for Calculation Rule 2******\\
{
  "id": 2,
  "name": "Calculation by choosen the smallest period tax",
  "taxPeriods": [
    {
      "id": 4,
      "type": 1,
      "fromDate": "2020-01-01T00:00:00.000Z",
      "tillDate": "2020-12-31T00:00:00.000Z",
      "taxRate": 0.2,
      "dates": []
    },
    {
      "id": 5,
      "type": 2,
      "fromDate": "2020-05-01T00:00:00.000Z",
      "tillDate": "2020-05-31T00:00:00.000Z",
      "taxRate": 0.4,
      "dates": []
    },
    {
      "id": 6,
      "type": 4,
      "fromDate": "0001-01-01T00:00:00.000Z",
      "tillDate": "0001-01-01T00:00:00.000Z",
      "taxRate": 0.1,
      "dates": [{
		  "id": 1,
          "date": "2020-01-01T00:00:00.000Z"
	  },
	  {
		  "id": 2,
          "date": "2020-12-25T00:00:00.000Z"
	  }]
    }
  ]
}
