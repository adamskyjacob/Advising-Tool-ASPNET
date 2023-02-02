const connectionString = "server=localhost;port=3306;database=advising;user=root;password=password;";
const aosMap = {
    "AREN": "Architectural Engineering",
    "AE": "Aerospace Engineering",
    "AS": "Air Science",
    "AB": "Arabic",
    "AR": "Art",
    "BCB": "Bioinformatics and Computational Biology",
    "BB": "Biology",
    "BME": "Biomedical Engineering",
    "BUS": "Business",
    "CH": "Chemistry",
    "CHE": "Chemical Engineering",
    "CE": "Civil Engineering",
    "CS": "Computer Science",
    "CN": "Chinese",
    "DS": "Data Science",
    "DEV": "Development",
    "ECON": "Economics",
    "ECE": "Electrical and Computer Engineering",
    "ES": "Engineering Science",
    "EN": "English",
    "ETR": "Entrepreneurship",
    "ENV": "Environmental Studies",
    "FIN": "Finance",
    "FP": "Fire Protection",
    "GE": "Geology",
    "GN": "German",
    "GOV": "Government, Political Science and Law",
    "HI": "History",
    "HU": "Humanities",
    "IMGD": "Interactive Media and Game Development",
    "INTL": "International and Global Studies",
    "ISE": "International Students - English",
    "MIS": "Management Information Systems",
    "MFE": "Manufacturing Engineering",
    "MKT": "Marketing",
    "MME": "Master of Mathematics in Educators",
    "MTE": "Material Science and Engineering",
    "MA": "Mathematical Sciences",
    "ME": "Mechanical Engineering",
    "ML": "Military Leadership",
    "MU": "Music",
    "NEU": "Neuroscience",
    "NSE": "Nuclear Science and Engineering",
    "OIE": "Operations and Industrial Engineering",
    "OBC": "Organizational Behavior and Change",
    "PY": "Philosophy",
    "PE": "Physical Education",
    "PH": "Physics",
    "PSY": "Psychology",
    "RE": "Religion",
    "RBE": "Robotics Engineering",
    "SS": "Social Science",
    "STS": "Society/Technology Studies",
    "SOC": "Sociology",
    "SP": "Spanish",
    "SD": "System Dynamics",
    "SYS": "Systems Engineering",
    "TH": "Theatre",
    "WR": "Writing"
}

const schedule = {
    years: [
        [
            ["CS101", "CS202", "CS303"],
            ["CS404", "CS505", "CS606"],
            ["CS101", "CS202", "CS303"],
            ["CS404", "CS505", "CS606"]
        ], [
            ["CS1101", "CS1202", "CS1303"],
            ["CS1404", "CS1505", "CS1606"],
            ["CS1101", "CS1202", "CS1303"],
            ["CS1404", "CS1505", "CS1606"]
        ], [
            ["CS2101", "CS2202", "CS2303"],
            ["CS2404", "CS2505", "CS2606"],
            ["CS2101", "CS2202", "CS2303"],
            ["CS2404", "CS2505", "CS2606"]
        ], [
            ["CS3101", "CS3202", "CS3303"],
            ["CS3404", "CS3505", "CS3606"],
            ["CS3101", "CS3202", "CS3303"],
            ["CS3404", "CS3505", "CS3606"]
        ]
    ]
}

const courseInfo = [
    {
        id: 'CS101',
        description: "This is a course 1",
        prereqs: []
    },
    {
        id: 'CS202',
        description: "This is a course 1",
        prereqs: ["CS101"]
    },
    {
        id: 'CS303',
        description: "This is a course 1",
        prereqs: ["CS202", "CS101"]
    },
    {
        id: 'CS404',
        description: "This is a course 1",
        prereqs: ["CS303", "CS202", "CS101"]
    },
    {
        id: 'CS505',
        description: "This is a course 1",
        prereqs: ["CS404", "CS303", "CS202", "CS101"]
    },
    {
        id: 'CS606',
        description: "This is a course 1",
        prereqs: ["CS505", "CS404", "CS303", "CS202", "CS101"]
    }
]