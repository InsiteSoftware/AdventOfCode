class Folder:
    def __init__(self, name, size, children):
        self.name = name
        self.size = size
        self.children = children

def calculateSize():
    folders = [Folder('/', 0, [])]
    workingFolders = []
    workingFolders.insert(0, folders[0])

    with open('input.txt', 'r') as file:
        contents = file.readlines()
        contents = contents[1:]
        
        for line in contents:
            line = line.strip()

            if (line == '$ ls'):
                continue
            elif (line == '$ cd ..'):
                # pop the current folder and add it to the full list
                temp = workingFolders[0]
                workingFolders = workingFolders[1:]
                folders.append(temp)
            elif (line.startswith('$ cd ')):
                # next folder is a child of the current folder...
                workingFolders.insert(0, findChild(line.split()[2], workingFolders[0].children))
            elif (not line.startswith('$ ')):
                if (line.startswith('dir')):
                    temp = Folder(line.split()[1], 0, [])
                    workingFolders[0].children.insert(0, temp)
                else:
                    workingFolders[0].size += int(line.split()[0])
        temp = workingFolders[0]
        workingFolders = workingFolders[1:]
        folders.append(temp)
    
    currentSpace = 70000000 - findSize(folders[0])
    result = 0
    for folder in folders:
        folderSize = findSize(folder)
        if (result == 0):
            result = folderSize
        if ((currentSpace + folderSize) > 30000000 and folderSize < result):
            result = folderSize

    print(result)

def findSize(folder):
    result = folder.size

    for child in folder.children:
        result += findSize(child)

    return result

def findChild(name, children):
    for child in children:
        if (child.name == name):
            return child
    
    print('you are a failure and you always will be')
    return Folder(name, 0, [])

calculateSize()
