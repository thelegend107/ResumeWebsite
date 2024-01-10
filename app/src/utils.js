import MD5 from 'crypto-js/md5'
import {
    mdiBookEducation,
    mdiHome,
    mdiLoginVariant,
    mdiLogoutVariant,
    mdiMenu,
    mdiKey,
    mdiHeart,
    mdiHeartOutline,
    mdiBriefcase,
    mdiAccount,
    mdiEmail,
    mdiFilePdfBox,
    mdiLinkedin,
    mdiGithub,
    mdiMicrosoft,
    mdiApplication,
    mdiDatabase,
    mdiDotNet,
    mdiGit,
    mdiIntegratedCircuitChip,
    mdiLanguageC,
    mdiLanguageCpp,
    mdiLanguageCsharp,
    mdiLanguageCss3,
    mdiLanguageHtml5,
    mdiLanguageJava,
    mdiLanguageJavascript,
    mdiLanguagePython,
    mdiMathIntegralBox,
    mdiMicrosoftAzure,
    mdiMicrosoftAzureDevops,
    mdiMicrosoftVisualStudio,
    mdiMicrosoftVisualStudioCode,
    mdiSalesforce,
    mdiSass,
    mdiVuejs,
    mdiTools,
    mdiFileCertificate,
    mdiChevronRight,
    mdiChevronLeft
} from '@mdi/js'

export const headerIconSize = 35
export const iconSize = 25

export const monthNames = [
    'JAN',
    'FEB',
    'MAR',
    'APR',
    'MAY',
    'JUNE',
    'JULY',
    'AUG',
    'SEPT',
    'OCT',
    'NOV',
    'DEC'
]

export const statusCode = {
    401: {
        name: '401: Unauthorized',
        description: [
            "You don't have permissions for this page.",
            'Please check your login info and permissions and try again.'
        ]
    },
    403: {
        name: '403: Forbidden',
        description: [
            "You don't have permissions for this page.",
            'Please check your login info and permissions and try again.'
        ]
    },
    404: {
        name: '404: Not Found',
        description: ['The requested route was not found.', 'Go home you are drunk.']
    }
}

export function displayAddress(obj) {
    let addressArray = []
    /*     if (obj.address1)
          addressArray.push(obj.address1); */
    if (obj.address2) addressArray.push(obj.address2)
    if (obj.city || obj.state) addressArray.push((obj.city + ' ' + obj.state.stateCode).trim())
    if (obj.country) addressArray.push(obj.country.ISO2)

    return addressArray.join(', ')
}

export function displayDate(string) {
    let displayDate = ''

    const date = new Date(string)
    const month = date.getMonth()
    const year = date.getFullYear()

    displayDate += monthNames[month] + ' ' + year

    return displayDate
}

export async function getUserInfo() {
    const response = await fetch('/.auth/me')
    const payload = await response.json()
    const { clientPrincipal } = payload
    return clientPrincipal
}

// Get Profile Pic based on Gravatar
export function getGravatarProfilePic(email, size = 250) {
    let baseUrl = 'https://gravatar.com/avatar/'
    let emailHash = MD5(email)

    let url = baseUrl + emailHash + '?size=' + size
    return url
}

export function showIconName(name) {
    let showName = name.trim().toLowerCase()

    switch (showName) {
        case '.net':
            return ''
        case '.net framework':
            return 'Framework'
        case 'c':
            return ''
        case 'c++':
            return ''
        case 'c#':
            return ''
        default:
            return name
    }
}

export function getIconPath(name) {
    let path = null
    switch (name.trim().toLowerCase()) {
        case 'heart':
            path = mdiHeart
            break
        case 'heartoutline':
            path = mdiHeartOutline
            break
        case 'certificate':
            path = mdiFileCertificate
            break
        case 'chevronright':
            path = mdiChevronRight
            break
        case 'chevronleft':
            path = mdiChevronLeft
            break
        case 'key':
            path = mdiKey
            break
        case 'login':
            path = mdiHeartOutline
            break
        case 'loginvariant':
            path = mdiLoginVariant
            break
        case 'logoutvariant':
            path = mdiLogoutVariant
            break
        case 'menu':
            path = mdiMenu
            break
        case 'home':
            path = mdiHome
            break
        case 'bookeducation':
            path = mdiBookEducation
            break
        case 'briefcase':
            path = mdiBriefcase
            break
        case 'tools':
            path = mdiTools
            break

        case 'linkedin':
            path = mdiLinkedin
            break
        case 'github':
            path = mdiGithub
            break
        case 'microsoft':
            path = mdiMicrosoft
            break
        case 'gravatar':
            path = mdiAccount
            break
        case 'pdf':
            path = mdiFilePdfBox
            break
        case 'email':
            path = mdiEmail
            break

        case 'azure':
            path = mdiMicrosoftAzure
            break
        case 'azure devops':
            path = mdiMicrosoftAzureDevops
            break
        case 'git':
            path = mdiGit
            break
        /*         case "boomi":
                path = mdiIntegratedCircuitChip;
                break; */
        case 'visual studio':
            path = mdiMicrosoftVisualStudio
            break
        case 'vscode':
            path = mdiMicrosoftVisualStudioCode
            break
        case 'pycharm':
            path = mdiLanguagePython
            break
        case 'matlab':
            path = mdiMathIntegralBox
            break

        case 'c#':
            path = mdiLanguageCsharp
            break
        case 'c++':
            path = mdiLanguageCpp
            break
        case 'c':
            path = mdiLanguageC
            break
        case 'python':
            path = mdiLanguagePython
            break
        case 'java':
            path = mdiLanguageJava
            break
        case 'javascript':
            path = mdiLanguageJavascript
            break
        case 'verilog':
            path = mdiIntegratedCircuitChip
            break
        case 'html':
            path = mdiLanguageHtml5
            break
        case 'css':
            path = mdiLanguageCss3
            break
        case 'sass':
            path = mdiSass
            break
        case 'jquery':
            path = mdiLanguageJavascript
            break

        case '.net':
            path = mdiDotNet
            break
        case '.net framework':
            path = mdiDotNet
            break
        case 'vue.js':
            path = mdiVuejs
            break

        case 'oracle sql':
            path = mdiDatabase
            break
        case 'microsoft sql':
            path = mdiDatabase
            break
        case 'mysql':
            path = mdiDatabase
            break
        case 'nosql':
            path = mdiDatabase
            break
        case 'postgresql':
            path = mdiDatabase
            break

        case 'salesforce':
            path = mdiSalesforce
            break
        default:
            path = mdiApplication
            break
    }

    return path
}

export function scrollMeTo(refName) {
    let element = document.getElementById(refName)
    let top = element.offsetTop
    window.scrollTo({
        top: top - 73.008,
        behavior: 'smooth'
    })
}

export function uniqueArray(a) {
    function onlyUnique(value, index, self) {
        return self.indexOf(value) === index
    }

    var unique = a.filter(onlyUnique)

    return unique
}
